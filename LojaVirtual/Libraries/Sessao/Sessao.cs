using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Sessao
{
    public class Sessao
    {
        private IHttpContextAccessor _context;
        public Sessao(IHttpContextAccessor context)
        {
            _context = context;
        }

        //CRUD - Cadastrar/Atualizar/Consultar/Remover - RemoverTodos/Exist

        public void Cadastrar(string Key, string valor)
        {
            _context.HttpContext.Session.SetString(Key, valor);
        }

        public void Atualizar(string Key, string valor)
        {
            if (Existe(Key))
            {
                _context.HttpContext.Session.Remove(Key);
            }
            _context.HttpContext.Session.SetString(Key, valor);
        }

        public void Remover(string Key)
        {
            _context.HttpContext.Session.Remove(Key);
        }

        public string Consultar(string Key)
        {
            return _context.HttpContext.Session.GetString(Key);
        }

        public bool Existe(string Key)
        {
            if(_context.HttpContext.Session.GetString(Key) == null)
            {
                return false;
            }
            return true;
        }

        public void RemoverTodos()
        {
            _context.HttpContext.Session.Clear();
        }
    }
}
