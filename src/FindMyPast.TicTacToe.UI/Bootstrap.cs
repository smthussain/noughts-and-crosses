using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FindMyPast.TicTacToe.Logic;
using FindMyPast.TicTacToe.Logic.Model;

namespace FindMyPast.TicTacToe.UI
{
    internal static class Bootstrap
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof (IBoard).Assembly).AsImplementedInterfaces();

            return builder.Build();
        }

    }
}
