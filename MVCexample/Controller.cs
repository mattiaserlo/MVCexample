using System;
using System.Diagnostics;

namespace MVCexample
{
  public class Controller : IEventListener
  {
    private Model mModel = null;

    public Controller(Form1 viewForm)
    {
      Event myNumberClickEvent = new Event(EventType.eventTypeNumberClick);
      viewForm.registerListener(this, myNumberClickEvent);

      Event myAddEvent = new Event(EventType.eventTypeAddClick);
      viewForm.registerListener(this, myAddEvent);

      Event mySubtractEvent = new Event(EventType.eventTypeSubtractClick);
      viewForm.registerListener(this, mySubtractEvent);

      Event myClearEvent = new Event(EventType.eventTypeClearClick);
      viewForm.registerListener(this, myClearEvent);

      Event myEqualsEvent = new Event(EventType.eventTypeEqualsClick);
      viewForm.registerListener(this, myEqualsEvent);
    }

    public void setModel(Model model)
    {
      mModel = model;
    }

    public void receivedEvent(Event ev)
    {
      switch (ev.getEventType())
      {
        case EventType.eventTypeNumberClick:
          numberClick(ev.getData());
          break;
        case EventType.eventTypeAddClick:
          addClick();
          break;
        case EventType.eventTypeSubtractClick:
          subtractClick();
          break;
        case EventType.eventTypeClearClick:
          clearClick();
          break;
        case EventType.eventTypeEqualsClick:
          equalsClick();
          break;
        default:
          Debug.WriteLine("Received unknown event: " + ev.getEventType());
          break;
      }
    }

    private void numberClick(int number)
    {
      Debug.WriteLine("You clicked number " + number);
      if (mModel != null)
      {
        mModel.pushNumber(number);
      }
    }

    private void addClick()
    {
      Debug.WriteLine("You clicked add");
      mModel.add();
    }

    private void subtractClick()
    {
      Debug.WriteLine("You clicked subtract");
      mModel.subtract();
    }

    private void clearClick()
    {
      Debug.WriteLine("You clicked clear");
      mModel.clear();
    }

    private void equalsClick()
    {
      Debug.WriteLine("You clicked equals");
      mModel.equals();
    }
  }
}
