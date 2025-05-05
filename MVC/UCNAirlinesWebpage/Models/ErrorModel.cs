using Microsoft.AspNetCore.Mvc;

namespace UCNAirlinesWebpage.Models
{
    public class ErrorModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }


    }

}