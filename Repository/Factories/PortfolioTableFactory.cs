using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;


namespace Repository
{
    public class PortfolioTableFactory : AutoFac<PortfolioTable>
    {

        public List<PortfolioTable> GetAllJoin()
        {
            string SQL = "SELECT ID, PortfolioSmallDesc, PortFolioImage, PortFolioTitle, PortfolioDesc, DemoLink FROM PortfolioTable";

            //string SQL = "SELECT MainTable.ID, AboutTitle, AboutInformation, UserInformation, UserGraphics, UserCodings, UserCV, PortfolioSmallDesc, PortFolioImage, PortFolioTitle, PortfolioDesc, PortfolioID FROM MainTable INNER JOIN PortfolioTable ON PortfolioTable.ID = PortfolioID";

            return ExecuteSQL<PortfolioTable>(SQL);
        }

        public PortfolioTable GetDetails(int ID)
        {
            string SQL = "SELECT ID, PortfolioSmallDesc, PortFolioImage, PortFolioTitle, PortfolioDesc, DemoLink FROM PortfolioTable WHERE ID = " + ID;
            //string SQL = "SELECT MainTable.ID, AboutTitle, AboutInformation, UserInformation, UserGraphics, UserCodings, UserCV, PortfolioSmallDesc, PortFolioImage, PortFolioTitle, PortfolioDesc, PortfolioID FROM MainTable INNER JOIN PortfolioTable ON PortfolioTable.ID = PortfolioID WHERE MainTable.ID =" + ID;

            return ExecuteSQL<PortfolioTable>(SQL)[0];
        }

        public void Updates(PortfolioTable input)
        {
            string SQL = "UPDATE PortfolioTable SET "
                + "PortfolioSmallDesc = '" + input.PortfolioSmallDesc + "', "
                + "PortFolioImage = '" + input.PortFolioImage + "' ,"
                + "PortFolioTitle = '" + input.PortFolioTitle + "' ,"
                + "PortfolioDesc = '" + input.PortfolioDesc
                + "' WHERE ID = " + input.ID;

            ExecuteSQL(SQL);
        }
    }
}
