using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserGraphicsTableFac : AutoFac<UserGraphicsTable>
    {

        public List<UserGraphicsTable> GetAllJoin()
        {
            string SQL = "SELECT ID, UserGraphics FROM UserGraphicsTable";

            return ExecuteSQL<UserGraphicsTable>(SQL);
        }

        public UserGraphicsTable GetByID(int ID)
        {
            string SQL = "SELECT ID, UserGraphics FROM UserGraphicsTable WHERE ID=" + ID;

            return ExecuteSQL<UserGraphicsTable>(SQL)[0];
        }
    }
}
