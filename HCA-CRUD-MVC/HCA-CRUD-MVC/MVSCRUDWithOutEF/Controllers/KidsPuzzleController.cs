using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KidsPuzzles.Data;
using KidsPuzzles.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace KidsPuzzles.Controllers
{
    public class KidsPuzzleController : Controller
    {        
        private readonly IConfiguration _configuration;

        public KidsPuzzleController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // GET: KidsPuzzle
        public IActionResult Index()
        {
            DataTable dtTbl = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DEVConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("udsp_Sel_KidsPuzzles", sqlConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.Fill(dtTbl);                
            }
            return View(dtTbl);
        }              
               
        // GET: KidsPuzzle/AddOrEdit/
        public IActionResult AddOrEdit(int? id)
        {
            KidsPuzzleViewModel kidsPuzzleViewModel = new KidsPuzzleViewModel();
            if (id > 0)
                kidsPuzzleViewModel = FetchPuzzleByID(id);

            return View(kidsPuzzleViewModel);
        }

        // POST: KidsPuzzle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("PuzzleID,PuzzleName,PuzzleDescription,PuzzlePrice,PuzzleRating")] KidsPuzzleViewModel kidsPuzzleViewModel)
        {
            if (ModelState.IsValid)
            {
                using(SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DEVConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("udsp_InsOrUpd_KidsPuzzle", sqlConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("PuzzleID", kidsPuzzleViewModel.PuzzleID);
                    sqlCmd.Parameters.AddWithValue("PuzzleName", kidsPuzzleViewModel.PuzzleName);
                    sqlCmd.Parameters.AddWithValue("PuzzleDescription", kidsPuzzleViewModel.PuzzleDescription);                    
                    sqlCmd.Parameters.AddWithValue("PuzzlePrice", kidsPuzzleViewModel.PuzzlePrice);
                    sqlCmd.Parameters.AddWithValue("PuzzleRating", kidsPuzzleViewModel.PuzzleRating);
                    sqlCmd.ExecuteNonQuery();
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: KidsPuzzle/Delete/5
        public IActionResult Delete(int? id)
        {
            KidsPuzzleViewModel kidsPuzzleViewModel = new KidsPuzzleViewModel();
            kidsPuzzleViewModel = FetchPuzzleByID(id);

            return View(kidsPuzzleViewModel);
        }

        // POST: KidsPuzzle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DEVConnection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("udsp_Del_KidsPuzzleByID", sqlConnection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("PuzzleID", id);                
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction(nameof(Index));
        }
        [NonAction]
        public KidsPuzzleViewModel FetchPuzzleByID(int? id)
        {
            KidsPuzzleViewModel kidsPuzzleViewModel = new KidsPuzzleViewModel();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DEVConnection")))
            {
                DataTable dtTbl = new DataTable();
                sqlConnection.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter("udsp_Sel_KidsPuzzleByID", sqlConnection);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("PuzzleID", id);

                sqlDa.Fill(dtTbl);

                if(dtTbl.Rows.Count == 1)
                {
                    kidsPuzzleViewModel.PuzzleID = Convert.ToInt32(dtTbl.Rows[0]["PuzzleID"].ToString());
                    kidsPuzzleViewModel.PuzzleName = dtTbl.Rows[0]["PuzzleName"].ToString();
                    kidsPuzzleViewModel.PuzzleDescription = dtTbl.Rows[0]["PuzzleDescription"].ToString();
                    kidsPuzzleViewModel.PuzzlePrice = Convert.ToInt32(dtTbl.Rows[0]["PuzzlePrice"].ToString());
                    kidsPuzzleViewModel.PuzzleRating = Convert.ToInt32(dtTbl.Rows[0]["PuzzleRating"].ToString());
                }
                return kidsPuzzleViewModel;
            }
        }
    }
}
