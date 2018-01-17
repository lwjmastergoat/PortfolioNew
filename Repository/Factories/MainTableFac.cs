using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MainTableFac : AutoFac<MainTable>
    {

        public MainTable GetAllJoin()
        {
            string SQL = "SELECT ID, AboutTitle, AboutInformation, UserCV, PortfolioID FROM MainTable";

            return ExecuteSQL<MainTable>(SQL)[0];
        }

        public void Updates(MainTable input)
        {
            string SQL = "UPDATE MainTable SET "
                + "AboutTitle = '" + input.AboutTitle + "', "
                + "AboutInformation = '" + input.AboutInformation + "' ,"
                + "UserCV = '" + input.UserCV
                + "' WHERE ID = " + input.ID;

            ExecuteSQL(SQL);
        }
    }
}
