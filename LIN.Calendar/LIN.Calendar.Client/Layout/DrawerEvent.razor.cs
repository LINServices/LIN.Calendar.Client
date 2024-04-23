using LIN.Calendar.Client.Pages;
using LIN.Types.Calendar.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LIN.Calendar.Client.Layout;


public partial class DrawerEvent
{


    public EventModel EventModel { get; set; } = new();
    

    /// <summary>
    /// ID del elemento Html.
    /// </summary>
    public string _id = $"element-{Guid.NewGuid()}";


    /// <summary>
    /// Patron de búsqueda.
    /// </summary>
    private string Pattern { get; set; } = string.Empty;


   

    /// <summary>
    /// Evento al ocultar.
    /// </summary>
    [Parameter]
    public Action OnHide { get; set; } = () => { };


    /// <summary>
    /// Evento al mostrar.
    /// </summary>
    [Parameter]
    public Action OnShow { get; set; } = () => { };


    [Parameter]
    public Action<EventModel> OnSuccess { get; set; } = (e) => { };




    /// <summary>
    /// Abrir drawer.
    /// </summary>
    public async void Show(EventModel model)
    {
        EventModel = model;
        await JS.InvokeVoidAsync("ShowDrawer", _id, "btn-close-panel-ide");
        StateHasChanged();
    }



    /// <summary>
    /// Evento al ocultar.
    /// </summary>
    [JSInvokable("OnHide")]
    public void HideJS() => OnHide.Invoke();



    /// <summary>
    /// Evento al abrir.
    /// </summary>
    [JSInvokable("OnShow")]
    public void ShowJS() => OnShow.Invoke();




    (string,string) GetClass()
    {
        switch(EventModel.Type)
        {
            case Types.Calendar.Enumerations.EventTypes.Event:
                return ("bg-amber-400", "text-amber-400");

            case Types.Calendar.Enumerations.EventTypes.Anniversary:
                return ("bg-blue-500", "text-blue-500");

            case Types.Calendar.Enumerations.EventTypes.Meeting:
                return ("bg-green-500", "text-green-500");

           default:
                return ("bg-rose-500", "text-rose-500");
        }
    }


    string GetFaltante(DateTime date)
    {

        var diferencia = date - DateTime.Now;


        
        if (diferencia.Ticks < 0)
        {
            if (diferencia.TotalDays < -1)
                return $"Hace {Math.Abs( diferencia.TotalDays):#} dias";


            if (diferencia.TotalMinutes < -60)
                return $"Hace {Math.Abs(diferencia.TotalHours *1):#} horas";


            return $"Hace {Math.Abs(diferencia.TotalMinutes * 1):#} minutos";
        }
            

        if (diferencia.TotalDays > 1)
            return $"Faltan {diferencia.TotalDays:#} dias";


        if (diferencia.TotalMinutes > 60)
            return $"Faltan {diferencia.TotalHours:#} horas";


        return $"Faltan {diferencia.TotalMinutes:#} minutos";




    }
   
   
}