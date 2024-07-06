using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace GestorMVC.Helpers
{
    public static class HtmlHelpers
    {
        public static IEnumerable<SelectListItem> EnumParaLista<T>() where T : Enum
        {
            var tipoEnum = typeof(T);
            var valoresEnum = Enum.GetValues(tipoEnum).Cast<T>();

            var listaSelect = new List<SelectListItem>();

            foreach (var valorEnum in valoresEnum)
            {
                var atributoDisplay = valorEnum.GetType()
                                               .GetMember(valorEnum.ToString())
                                               .First()
                                               .GetCustomAttributes(typeof(DisplayAttribute), false)
                                               .FirstOrDefault() as DisplayAttribute;

                string nomeExibicao = atributoDisplay != null ? atributoDisplay.Name : valorEnum.ToString();

                listaSelect.Add(new SelectListItem
                {
                    Value = valorEnum.ToString(),
                    Text = nomeExibicao
                });
            }

            return listaSelect;
        }
    }
}
