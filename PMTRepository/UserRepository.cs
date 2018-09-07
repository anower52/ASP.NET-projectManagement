using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMTRepository
{
    public class UserRepository : IUserRepository
    {
        PMTDBContext context = new PMTDBContext();
        public User_Info login(string username, string password)
        {
            User_Info u = context.UserInfo.SingleOrDefault(x => x.UserName == username && x.Password == password);
            return u;
        }
        public List<User_Info> all_user()
        {
            return context.UserInfo.ToList();
        }
        public User_Info user (int id)
        {
            return context.UserInfo.SingleOrDefault(u => u.Id == id);
        }
        public int Insert(User_Info user)
        {
            context.UserInfo.Add(user);
            return context.SaveChanges();
        }
        public int Delete (int id)
        {
            User_Info UserToDelete = context.UserInfo.SingleOrDefault(u => u.Id == id);
            context.UserInfo.Remove(UserToDelete);
            return context.SaveChanges();
        }
        public int Update (User_Info user)
        {
            User_Info UserToUpdate = context.UserInfo.SingleOrDefault(u => u.Id == user.Id );
            UserToUpdate.Name = user.Name;
            UserToUpdate.UserEmail = user.UserEmail;
            UserToUpdate.UserType = user.UserType;
            UserToUpdate.Dob = user.Dob;
            UserToUpdate.Gender = user.Gender;
            UserToUpdate.IsActive = user.IsActive;
            return context.SaveChanges();
        }
        public string assignToUser(int id)
        {
            List<Assign_Project> ap = context.AssignProjects.Where(x => x.ProjectId == id).ToList();
            string assinTo = "";
            bool toggle = false;
            foreach (var item in ap)
            {
                User_Info u = this.user(item.UserId);
                if (toggle)
                {
                    assinTo += "," + u.Name;
                }
                else
                {
                    assinTo +=u.Name;
                    toggle = true;
                }  
            }
            return assinTo;
        }

        public List<User_Info> userByproject(int id)
        {
            List<Assign_Project> ap = context.AssignProjects.Where(x => x.ProjectId == id).ToList();
            List<User_Info> s = new List<User_Info>();
            foreach (var item in ap)
            {
                User_Info u = this.user(item.UserId);
                s.Add(u);
            }
            return s;
        }
    }
}
