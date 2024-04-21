using LIN.Calendar.Client.Pages;
using LIN.Types.Calendar.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LIN.Calendar.Client.Layout;


public partial class DrawerPeople
{


    public EventModel EventModel { get; set; } = new()
    {
        DateStart = DateTime.Now,
    };
    

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
    public async void Show()
    {
        await JS.InvokeVoidAsync("ShowDrawer", _id, "btn-close-panel-ide");
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



   
    async void Create()
    {

        var actual = EventModel;
        EventModel = new()
        {
            DateStart = DateTime.Now,
        };

        var response = await LIN.Access.Calendar.Controllers.Events.Create(LIN.Access.Calendar.Session.Instance.Token, actual);

        OnSuccess(actual);
    }


}