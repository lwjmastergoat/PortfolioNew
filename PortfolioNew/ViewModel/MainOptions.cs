using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;

namespace PortfolioNew
{
    public class MainOptions
    {
        public List<PortfolioTable> Portfolio { get; set; }

        public List<UserInformationTable> UserInformation { get; set; }

        public List<UserGraphicsTable> UserGraphics { get; set; }

        public List<UserCodingTable> UserCoding { get; set; }
        public MainTable MainTables { get; set; }

    }
}