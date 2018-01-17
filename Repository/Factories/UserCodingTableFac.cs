using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserCodingTableFac : AutoFac<UserCodingTable>
    {

        public List<UserCodingTable> GetAllJoin()
        {
            string SQL = "SELECT ID, UserCodings FROM UserCodingTable";

            return ExecuteSQL<UserCodingTable>(SQL);
        }

        public UserCodingTable GetByID(int ID)
        {
            string SQL = "SELECT ID, UserCodings FROM UserCodingTable WHERE ID=" + ID;

            return ExecuteSQL<UserCodingTable>(SQL)[0];
        }
    }
}
