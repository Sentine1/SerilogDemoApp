﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("You requested the Index Page.");
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    if (i == 13)
                        throw new Exception("This is our demo exception");
                    else
                        _logger.LogInformation("The value of i is {LoopCountValue}", i);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We caught this exception in the Index Get call.");
            }
        }
    }
}
