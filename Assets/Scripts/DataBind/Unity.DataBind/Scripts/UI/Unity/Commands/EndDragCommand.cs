namespace DataBind.UI.Unity.Commands
{
    using DataBind.Foundation.Commands;

    using UnityEngine;
    using UnityEngine.EventSystems;

    /// <summary>
    ///   Command which is invoked when dragging the element ended.
    ///   Parameters:
    ///   - Pointer event data.
    /// </summary>
    [AddComponentMenu("Data Bind/UnityUI/Commands/[DB] End Drag Command (Unity)")]
    public class EndDragCommand : Command, IEndDragHandler
    {
        /// <summary>
        ///   Called when dragging the element ended.
        /// </summary>
        /// <param name="eventData">Data of the pointer which did the dragging.</param>
        public void OnEndDrag(PointerEventData eventData)
        {
            this.InvokeCommand(eventData);
        }
    }
}