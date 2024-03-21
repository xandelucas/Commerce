﻿namespace Commerce.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public int Estoque{ get; set; }
    }
}
