using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Repository
{
    public class AccountTableFac : AutoFac<AccountTable>
    {
        public AccountTable Login(string email, string password)
        {
            using (var cmd = new SqlCommand("SELECT * FROM AccountTable WHERE Email=@Email AND Password=@Password", Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                var mapper = new Mapper<AccountTable>();
                var r = cmd.ExecuteReader();
                AccountTable per = new Repository.AccountTable();

                if (r.Read())
                {
                    per = mapper.Map(r);
                }

                r.Close();
                cmd.Connection.Close();
                return per;
            }
        }
    }
}
