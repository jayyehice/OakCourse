using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL
{
    public class CategoryBLL
    {
        CategoryDAO dao = new CategoryDAO();
        PostBLL postbll = new PostBLL();

        public static IEnumerable<SelectListItem> GetCategoriesForDropdown()
        {
            return CategoryDAO.GetCategoriesForDropdown();
        }

        public bool AddCategory(CategoryDTO model)
        {
            Category category = new Category();
            category.CategoryName = model.CategoryName;
            category.AddDate = DateTime.Now;
            category.LastUpdateDate = DateTime.Now;
            category.LastUpdateUserID = UserStatic.UserID;

            int ID = dao.AddCategory(category);

            LogDAO.AddLog(General.ProcessType.CategoryAdd, General.TableName.Category, ID);

            return true;
        }

        public List<PostImageDTO> DeleteCategory(int ID)
        {
            List<Post> postlist = dao.DeleteCategory(ID);
            LogDAO.AddLog(General.ProcessType.CategoryDelete, General.TableName.Category, ID);
            List<PostImageDTO> imagelist = new List<PostImageDTO>();
            foreach (Post post in postlist)
            {
                List<PostImageDTO> imagelist2 = postbll.DeletePost(post.ID);
                LogDAO.AddLog(General.ProcessType.PostDelete, General.TableName.post, post.ID);

                foreach(PostImageDTO item in imagelist2)
                {
                    imagelist.Add(item);
                }
            }

            return imagelist;
        }

        public List<CategoryDTO> GetCategories()
        {
            return dao.GetCategories();
        }

        public CategoryDTO GetCategoryWithID(int ID)
        {
            return dao.GetCategoryWithID(ID);
        }

        public bool UpdateCategory(CategoryDTO model)
        {
            dao.UpdateCategory(model);

            LogDAO.AddLog(General.ProcessType.CategoryUpdate, General.TableName.Category, model.ID);

            return true;
        }
    }
}
