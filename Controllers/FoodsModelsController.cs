using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Home.Contex;
using Home.Models;
using Npgsql;
using System.Data;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Home.Controllers
{
    public class FoodPriceViewModel
    {
        public decimal TotalFoodPrice { get; set; }
        public List<FoodsModel> FoodsList { get; set; } = new List<FoodsModel>();
    }
    public class FoodsModelsController : Controller
    {
        public FoodsModelsController(IConfiguration configuration, AppDbContext context)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("WebApiDatabase")
                ?? throw new ArgumentNullException("ConnectionString");
        }
        private readonly string _connectionString;
        public class DateRange
        {
            public DateOnly StartDate { get; set; }
            public DateOnly EndDate { get; set; }
        }
        [HttpPost]

        public IActionResult GetTotalFoodPrice([FromBody] DateRange dateRange)

        {
            if (!ModelState.IsValid || dateRange == null)
            {
                return BadRequest("Invalid date range.");
            }
            decimal totalFoodPrice = 0;

            var foodsList = new List<FoodsModel>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand(
                @"
                    SELECT SUM(CASE 
                                 WHEN REPLACE(CAST(foodprice AS VARCHAR(100)), ',', '.') ~ '^[0-9]+(\.[0-9]+)?$' THEN CAST(foodprice AS DECIMAL)
                                 ELSE 0
                             END) AS total_food_price
                    FROM ""Foods""
                    WHERE fooddate BETWEEN @startDate AND @endDate;

                    SELECT *
                    FROM ""Foods""
                    WHERE fooddate BETWEEN @startDate AND @endDate;
                ", connection))

                {
                    command.Parameters.AddWithValue("@startDate", dateRange.StartDate);
                    command.Parameters.AddWithValue("@endDate", dateRange.EndDate);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalFoodPrice = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                        }

                        reader.NextResult();
                        while (reader.Read())
                        {
                            var food = new FoodsModel
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                foodName = reader.GetString(reader.GetOrdinal("foodName")),
                                foodCategory = reader.GetString(reader.GetOrdinal("foodCategory")),
                                foodprice = reader.GetString(reader.GetOrdinal("foodprice")),
                                foodcomment = reader.GetString(reader.GetOrdinal("foodcomment")),
                                fooddate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("fooddate")))
                            };
                            foodsList.Add(food);
                        }
                    }
                        
                    var result = command.ExecuteScalar();
                    totalFoodPrice = result != DBNull.Value ? (decimal)result : 0;
                }

                
            }

            var viewModel = new FoodPriceViewModel
            {
                TotalFoodPrice = totalFoodPrice,
                FoodsList = foodsList
            };

            return Json(viewModel);
        }
            
        private readonly AppDbContext _context;

        // GET: FoodsModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Foods.ToListAsync());
        }

        // GET: FoodsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodsModel = await _context.Foods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodsModel == null)
            {
                return NotFound();
            }

            return View(foodsModel);
        }

        // GET: FoodsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,foodName,foodCategory,foodprice,foodcomment,fooddate")] FoodsModel foodsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodsModel);
        }

        // GET: FoodsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodsModel = await _context.Foods.FindAsync(id);
            if (foodsModel == null)
            {
                return NotFound();
            }
            return View(foodsModel);
        }

        // POST: FoodsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,foodName,foodCategory,foodprice,foodcomment,fooddate")] FoodsModel foodsModel)
        {
            if (id != foodsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodsModelExists(foodsModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(foodsModel);
        }

        // GET: FoodsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodsModel = await _context.Foods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodsModel == null)
            {
                return NotFound();
            }

            return View(foodsModel);
        }

        // POST: FoodsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodsModel = await _context.Foods.FindAsync(id);
            if (foodsModel != null)
            {
                _context.Foods.Remove(foodsModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodsModelExists(int id)
        {
            return _context.Foods.Any(e => e.Id == id);
        }
    }
}
