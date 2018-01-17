using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserInformationTableFac : AutoFac<UserInformationTable>
    {
        public List<UserInformationTable> GetAllJoin()
        {
            string SQL = "SELECT ID, UserInformation FROM UserInformationTable";

            return ExecuteSQL<UserInformationTable>(SQL);
        }

        public UserInformationTable GetByID(int ID)
        {
            string SQL = "SELECT ID, UserInformation FROM UserInformationTable WHERE ID=" + ID;

            return ExecuteSQL<UserInformationTable>(SQL)[0];
        }

    }
}
