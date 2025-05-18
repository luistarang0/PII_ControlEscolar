using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PII_ControlEscolar.Utilities
{
    internal class Formas
    {
        internal static void InicializaForma(Form form_child, Form form_parent)
        {
            //Inicializamos la forma

            //Propiedades basicas
            form_child.MdiParent = form_parent; //Asignar el padre al MDI
            form_child.FormBorderStyle = FormBorderStyle.Sizable; //Permite redimensionar
            form_child.MaximizeBox = true; //Permite Maximizar
            form_child.MinimizeBox = true; //Permite Minimizar
            form_child.WindowState = FormWindowState.Normal; //Estado inicial de la ventana

            //Propiedades de control
            form_child.ControlBox = true; //Mostrar botones de control (Minimizar, maximizar)
            form_child.ShowIcon = true; // Mostrar icono en la barra de titulo
            form_child.ShowInTaskbar = false; //No mostrar en la barra de tareas

            //Propiedades de tamaño 
            form_child.AutoScaleMode = AutoScaleMode.Font; // Modo de escalado 
            form_child.ClientSize = new Size(860, 600); // Tamaño inicial 
            form_child.MinimumSize = new Size(400, 300); // Tamaño minimo permitido 
            form_child.MaximumSize = new Size(3440, 1440); // Tamaño máximo permitido 

            //Propiedades de inicio 
            form_child.StartPosition = FormStartPosition.CenterScreen; // Posición inicial 

            //Propiedades de comportamiento 
            form_child.AutoScroll = true; // Permitir scroll si el contenido es mayor que la ventana 
            form_child.KeyPreview = true; // Permitir que el formulario reciba eventos de teclado

        }

    }
}
