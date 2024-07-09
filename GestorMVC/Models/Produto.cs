using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using GestorMVC.Models.Enums;

namespace GestorMVC.Models
{
    public class Produto
    {
        public Produto()
        {
            
        }

        public Produto(int id, string nome, CategoriaProduto categoria, int quantidade, decimal preco, int faturaId, DateOnly? validade = null)
        {
            Id = id;
            Nome = nome;
            Categoria = categoria;
            Quantidade = quantidade;
            Validade = validade;
            Preco = preco;
            FaturaId = faturaId;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public CategoriaProduto Categoria { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser pelo menos 1.")]
        public int Quantidade { get; set; }
        
        public DateOnly? Validade { get; set; }
        
        [Display(Name = "Preço Unidade")]
        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Display(Name = "Id da Fatura")]
        [Required(ErrorMessage = "O ID da fatura é obrigatório.")]
        public int FaturaId { get; set;}

        [ForeignKey("FaturaId")]
        public Fatura Fatura { get; set; }

    }
}