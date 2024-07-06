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

        [StringLength(100)]
        public string Nome { get; set; }

        public CategoriaProduto Categoria { get; set; }
        public int Quantidade { get; set; }
        public DateOnly? Validade { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }
        public int FaturaId { get; set;}

        [ForeignKey("FaturaId")]
        public Fatura Fatura { get; set; }

    }
}