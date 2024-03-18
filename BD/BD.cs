using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BD.RestCafeDataSetTableAdapters;

namespace BD
{
    public class server
    {
        public static UsersTableAdapter users = new UsersTableAdapter();
        public static RolesTableAdapter roles = new RolesTableAdapter();
        public static ReservedTableAdapter reserved = new ReservedTableAdapter();
        public static TablessTableAdapter tables = new TablessTableAdapter();
        public static OrdersTableAdapter orders = new OrdersTableAdapter();
        public static MenuTableAdapter menu = new MenuTableAdapter();
        public static IEnumerable getUsers() => users.GetData();

        public static IEnumerable getRoles() => roles.GetData();

        public static IEnumerable getReserved() => reserved.GetData();

        public static IEnumerable getTabless() => tables.GetData();
        public static IEnumerable getOrders() => orders.GetData();
        public static IEnumerable getMenu() => menu.GetData();

        public static List<string> getUser(int id)
        {
            var list = new List<string>();
            var a = users.GetData().Rows;
            for (int i = 0; i < a.Count; i++)
            {
                if (Convert.ToInt32(a[i][0]) == id)
                {
                    for (int j = 1; j < getColumnsUsers().Count - 1; j++)
                    {
                        list.Add(a[i][j].ToString());
                    }
                    return list;
                }
            }
            return new List<string>();
        }

        public static List<string> getColumnsTable()
        {
            var b = new List<string>();
            foreach (var a in tables.GetData().Columns)
                b.Add(a.ToString());
            return b;
        }
        public static List<string> getColumnsRoles()
        {
            var b = new List<string>();
            foreach (var a in roles.GetData().Columns)
                b.Add(a.ToString());
            return b;
        }
        public static List<string> getColumnsUsers()
        {
            var b = new List<string>();
            foreach (var a in users.GetData().Columns)
                b.Add(a.ToString());
            return b;
        }
        public static List<string> getColumnsReserved()
        {
            var b = new List<string>();
            foreach (var a in reserved.GetData().Columns)
                b.Add(a.ToString());
            return b;
        }
        public static List<string> getColumnsOrders()
        {
            var b = new List<string>();
            foreach (var a in orders.GetData().Columns)
                b.Add(a.ToString());
            return b;
        }
        public static List<string> getColumnsMenu()
        {
            var b = new List<string>();
            foreach (var a in menu.GetData().Columns)
                b.Add(a.ToString());
            return b;
        }

        public static bool Auth(string login, string password, out string role, out int id)
        {
            var a = users.GetData().Rows;
            for (int i = 0; i < a.Count; i++) if (a[i][5].ToString().Replace(" ", "") == login && a[i][6].ToString().Replace(" ", "") == password)
                {
                    role = getRole(Convert.ToInt32(a[i][7])).Replace(" ", "");
                    id = Convert.ToInt32(a[i][0].ToString());
                    return true;
                }
            id = -1;
            role = string.Empty;
            return false;
        }
        public static List<string> getMenuPanel()
        {
            var result = new List<string>();
            var a = menu.GetData().Rows;
            for (int i = 0; i < a.Count; i++) result.Add(a[i][1].ToString());
            return result;
        }
        public static string getRole(int id)
        {
            for (int i = 0; i < roles.GetData().Rows.Count; i++) if (Convert.ToInt32(roles.GetData().Rows[i][0]) == id) return roles.GetData().Rows[i][1].ToString();
            return string.Empty;
        }

        public static void Reg(string firstanme, string Secondname, string patronymic, string phoneNumber, string login, string password) => users.InsertQuery(firstanme, Secondname, patronymic, Convert.ToInt32(phoneNumber.Replace("-", "").Replace(" ", "").Replace("+", "")), login, password, 5);

        public static IEnumerable updateTable(string seats, string ReserveStatus, int id)
        {
            tables.UpdateQuery(Convert.ToInt32(seats), Convert.ToInt32(ReserveStatus), id);
            return tables.GetData();
        }
        public static IEnumerable deleteTable(int id)
        {
            tables.DeleteQuery(id);
            return tables.GetData();
        }
        public static IEnumerable createTable(string seats, string status)
        {
            tables.InsertQuery(Convert.ToInt32(seats), Convert.ToInt32(status));
            return tables.GetData();
        }

        public static IEnumerable createRole(string title) { roles.InsertQuery(Title: title); return roles.GetData(); }

        public static IEnumerable updateRole(string title, int id) { roles.UpdateQuery(title, id); return roles.GetData(); }
        public static IEnumerable deleteRole(int id) { roles.DeleteQuery(id); return roles.GetData(); }

        public static IEnumerable updateUser(string Firstname, string Secondname, string Patronymic, string phoneNumber, string Loginn, string Pass, string RoleID, int Original_UserID) { users.UpdateQuery(Firstname, Secondname, Patronymic, Convert.ToInt32(phoneNumber.Replace("-", "").Replace(" ", "").Replace("+", "")), Loginn, Pass, Convert.ToInt32(RoleID), Original_UserID); return users.GetData(); }
        public static IEnumerable createUser(string Firstname, string Secondname, string Patronymic, string phoneNumber, string Loginn, string Pass, string RoleID) { users.InsertQuery(Firstname, Secondname, Patronymic, Convert.ToInt32(phoneNumber.Replace("-", "").Replace(" ", "").Replace("+", "")), Loginn, Pass, Convert.ToInt32(RoleID)); return users.GetData(); }
        public static IEnumerable deleteUser(int id) { users.DeleteQuery(id); return users.GetData(); }
        public static IEnumerable createMenu(string title, string descript, string price) { menu.InsertQuery(title, descript, Convert.ToInt32(price)); return menu.GetData(); }
        public static IEnumerable deleteMenu(int id) { menu.DeleteQuery(id); return menu.GetData(); }

        public static IEnumerable updateMenu(string title, string descript, string price, int id) { menu.UpdateQuery(title, descript, Convert.ToInt32(price), id); return menu.GetData(); }

        public static IEnumerable createReserved(string datestart, string dateend) { reserved.InsertQuery(datestart, dateend, true); return reserved.GetData(); }

        public static IEnumerable updateReserved(string datestart, string dateend, bool reserv, int id) { reserved.UpdateQuery(datestart, dateend, reserv, id); return reserved.GetData(); }
        public static IEnumerable deleteReserved(int id) { reserved.DeleteQuery(id); return reserved.GetData(); }

        public static IEnumerable createOrder(int id, string menu_content) { orders.InsertQuery(true, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), id, getMenuID(menu_content)); return orders.GetData(); }

        public static int getMenuID(string menu_content)
        {
            var a = menu.GetData().Rows;
            for (int i = 0; i < a.Count; i++) if (a[i][1].ToString().Replace(" ", "") == menu_content.Replace(" ", "")) return Convert.ToInt32(a[i][0]);
            return 0;
        }
        public static IEnumerable updateOrder(string active, string date, string time, string id, string menuid, int update_id) { orders.UpdateQuery(active == "True", date, time, Convert.ToInt32(id), Convert.ToInt32(menuid), update_id); return orders.GetData(); }
        public static IEnumerable deleteOrder(int id) { orders.DeleteQuery(id); return orders.GetData(); }

        public static IEnumerable createOrders(string active, string date, string time, string id, string menuid) { orders.InsertQuery(active == "True", date, time, Convert.ToInt32(id), Convert.ToInt32(menuid)); return orders.GetData(); }
    }
}
