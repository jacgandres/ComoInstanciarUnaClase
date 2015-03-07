using System;
using System.Collections.Generic;
using GenericCustomLog.Model;
using GenericCustomLog.Persistence;

namespace GenericCustomLog.BusinessLogic
{
    public class CategoryFacade : ICategory
    {
        private CategoryDAO categorydao;

        public CategoryFacade()
        {
            categorydao = new CategoryDAO();
        }

        #region Miembros de ICategory

        public List<Category> GetAllCategories()
        {
            try
            {
                return categorydao.GetAllCategories();
            }
            catch (Exception)
            {
                //TODO:agregar el LOG
                return null;
            }
        }
        #endregion
    }
}