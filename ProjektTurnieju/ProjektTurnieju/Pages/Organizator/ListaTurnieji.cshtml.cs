using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektTurnieju.Data;
using ProjektTurnieju.DBActions;
using ProjektTurnieju.Models;

namespace ProjektTurnieju.Pages.Organizator
{
    public class ListaTurniejiModel : PageModel
    {
        public List<Turniej> turniejList;
        public void OnGet()
        {
            DBTurniej database = new DBTurniej();
            turniejList = database.getList();
        }
    }
}
