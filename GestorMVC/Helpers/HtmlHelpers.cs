using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                string? nomeExibicao = valorEnum.GetType()
                                               .GetMember(valorEnum.ToString())
                                               .First()
                                               .GetCustomAttributes(typeof(DisplayAttribute), false)
                                               .FirstOrDefault() is DisplayAttribute atributoDisplay ? atributoDisplay.Name : valorEnum.ToString();

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
