using System;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}