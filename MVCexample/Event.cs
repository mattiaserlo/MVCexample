using System;
using System.Collections.Generic;
using System.Text;

namespace MVCexample
{
  public enum EventType
  {
    eventTypeNumberClick,
    eventTypeAddClick,
    eventTypeSubtractClick,
    eventTypeClearClick,
    eventTypeEqualsClick
  }

  public class Event
  {
    private EventType mEventType;
    private int mData = 0;

    public Event(EventType eventType)
    {
      mEventType = eventType;
    }

    public Event(EventType eventType, int data)
    {
      mEventType = eventType;
      mData = data;
    }

    public EventType getEventType()
    {
      return mEventType;
    }

    public int getData()
    {
      return mData;
    }
  }
}

