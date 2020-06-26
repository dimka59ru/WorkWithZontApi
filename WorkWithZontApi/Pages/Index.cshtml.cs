using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WorkWithZontApi.Services;

namespace WorkWithZontApi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ZontService _zontService;

        public IndexModel(ILogger<IndexModel> logger, ZontService zontService)
        {
            _logger = logger;
            _zontService = zontService;
        }

        public void OnGet()
        {

        }
    }
}
