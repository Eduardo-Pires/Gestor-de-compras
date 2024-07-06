using System.ComponentModel.DataAnnotations;

namespace GestorMVC.Models.Enums
{
    public enum EstadoFatura
    {
        Pendente,
        Vencida,
        Paga,
        [Display(Name = "Parcialmente Paga")]
        ParcialmentePaga,
        Cancelada,
        Atrasada,
        Rejeitada
    }
}