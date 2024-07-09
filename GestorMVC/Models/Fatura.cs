using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GestorMVC.Models.Enums;

namespace GestorMVC.Models
{
    public class Fatura
    {
        public Fatura()
        {
            
        }

        public Fatura(int id, decimal totalCompra, TipoPagamento tipoPagamento, DateOnly dataCompra, EstadoFatura estado, string recebedor, int? parcelas = null)
        {
            Id = id;
            TotalCompra = totalCompra;
            TipoPagamento = tipoPagamento;
            DataCompra = dataCompra;
            Estado = estado;
            Recebedor = recebedor;
            Parcelas = parcelas;
        }
        public int Id { get; set; }

        [Display(Name = "Total")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalCompra {get; set;}

        [Required(ErrorMessage = "O tipo do pagamento é obrigatório")]
        [Display(Name = "Tipo Pagamento")]
        public TipoPagamento TipoPagamento { get; set; }

        [Required(ErrorMessage = "A data da Compra é obrigatória")]
        [Display(Name = "Data")]
        public DateOnly DataCompra { get; set;}
        [Range(1, int.MaxValue, ErrorMessage = "O número de parcelas deve ser maior ou igual a 0.")]
        public int? Parcelas { get; set; }

        [Required(ErrorMessage = "O Estado da Fatura é obrigatório")]
        public EstadoFatura Estado {get; set; }
        
        [Required(ErrorMessage = "O nome do recebedor é obrigatório.")]
        [StringLength(150)]
        public string Recebedor { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}