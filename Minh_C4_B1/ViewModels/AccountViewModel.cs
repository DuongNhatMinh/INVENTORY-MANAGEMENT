using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_C3_B1
{
    class AccountViewModel
    {
        public Account Acc = new Account();
        public List<Account> lstAcc = new List<Account>();
        public RepositoryBase<Account> accRepo { get; set; }
        private static UnitOfWork unitofwork
        {
            get; set;
        }

        public void getList()
        {
            unitofwork = new UnitOfWork();
            accRepo = unitofwork.GetRepositoryAccount;
            lstAcc = getList("/Accounts/Account");
        }

        public List<Account> getList(string xPath)
        {
            string UserName = string.Empty;
            string Password = string.Empty;
            int Status = 0;
            DataProvider.Instance.pathData = "data/Account/Account.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            foreach (XmlNode node in lstNode)
            {
                UserName = node.Attributes["Username"].Value;
                Password = node.Attributes["Password"].Value;
                Status = Int32.Parse(node.Attributes["Status"].Value);
                Acc = new Account(UserName, Password, Status);
                lstAcc.Add(Acc);
            }
           
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstAcc;
        }

        public int Compare(string user, string password)
        {
            for(int i = 0; i < lstAcc.Count; i++)
            {
                if (lstAcc[i].UserName == user && lstAcc[i].Password == password)
                    return i;
            }
            return -1;
        }

        public void Update(string xPath, int op)
        {
            DataProvider.Instance.pathData = "data/Account/Account.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            var node = DataProvider.Instance.getNode(xPath);
            node.Attributes["Status"].Value = op.ToString();
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }

        public void Update(string xPath, Account acc)
        {
            DataProvider.Instance.pathData = "data/Account/Account.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            var node = DataProvider.Instance.getNode(xPath);
            node.Attributes["Username"].Value = acc.UserName;
            node.Attributes["Password"].Value = acc.Password;
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }

        public void Create(Account acc)
        {
            DataProvider.Instance.pathData = "data/Account/Account.xml";
            var newNode = DataProvider.Instance.createNode("Account");
            var attr1 = DataProvider.Instance.createAttr("Username");
            attr1.Value = acc.UserName;
            var attr2 = DataProvider.Instance.createAttr("Password");
            attr2.Value = acc.Password;
            var attr3 = DataProvider.Instance.createAttr("Status");
            attr3.Value = acc.Status.ToString();
            newNode.Attributes.Append(attr1);
            newNode.Attributes.Append(attr2);
            newNode.Attributes.Append(attr3);
            //newNode.InnerText = string.Empty;
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            DataProvider.Instance.AppendNode(DataProvider.Instance.nodeRoot, newNode);
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }
    }
}
