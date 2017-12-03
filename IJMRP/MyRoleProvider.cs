using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using IJMRP.Models;

namespace IJMRP
{
    public class MyRoleProvider : RoleProvider
    {
        private int _cacheTimeoutInMinute = 20;

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        //public override string[] GetRolesForUser(string username)
        //{
        //    throw new NotImplementedException();
        //}

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        //  public override string GetRolesForUser(string username)
        {
            // db = new HRMS_DATBASEEntities();
            using (dbintjmrpEntities objContext = new dbintjmrpEntities())
            {
                var objUser = objContext.tblUserLogins.FirstOrDefault(x => x.U_USERID == username);
                if (objUser == null)
                {
                    return null;
                }
                else
                {

                    // string[] ret = objUser.Roles.Select(x => x.RoleName).ToArray();

                    //string[] ret8 = objContext.tblUserLogins.Select(x => x.U_USERID == username).Select(a=>a.).ToArray();
                    var ret2 = ((from r in objContext.tblUserLogins where r.U_USERID == objUser.U_USERID select new { r.U_ROLE }).FirstOrDefault()).U_ROLE;
                    //  string[] ret ;//= {"mm"};
                    // string s = ret2.U_ROLE;
                    var myList = new List<string>();
                    myList.Add(ret2);
                    // myList.add("item1");
                    // myList.add("item2");

                    string[] ret = myList.ToArray();

                    return ret;
                }
            }
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}