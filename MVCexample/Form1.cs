using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MVCexample
{
  public partial class Form1 : Form, ISubscription
  {
    List<IEventListener> mNumberClickListeners = new List<IEventListener>();
    List<IEventListener> mAddClickListeners = new List<IEventListener>();
    List<IEventListener> mSubtractClickListeners = new List<IEventListener>();
    List<IEventListener> mClearClickListeners = new List<IEventListener>();
    List<IEventListener> mEqualsClickListeners = new List<IEventListener>();

    public Form1()
    {
      InitializeComponent();
    }

    private PubSub mPubSub = null;

    public void setPubSub(PubSub pubSub)
    {
      mPubSub = pubSub;
      mPubSub.subscribe(this, SubscriptionType.NUMBER_UPDATED);
    }

    public void registerListener(IEventListener listener, Event ev)
    {
      switch (ev.getEventType())
      {
        case EventType.eventTypeNumberClick:
          mNumberClickListeners.Add(listener);
          break;
        case EventType.eventTypeAddClick:
          mAddClickListeners.Add(listener);
          break;
        case EventType.eventTypeSubtractClick:
          mSubtractClickListeners.Add(listener);
          break;
        case EventType.eventTypeClearClick:
          mClearClickListeners.Add(listener);
          break;
        case EventType.eventTypeEqualsClick:
          mEqualsClickListeners.Add(listener);
          break;
        default:
          Debug.WriteLine("Tried to register listener for unknown event type " + ev.getEventType());
          break;
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < mNumberClickListeners.Count; i++)
      {
        Event ev = new Event(EventType.eventTypeNumberClick, 1);
        mNumberClickListeners[i].receivedEvent(ev);
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < mNumberClickListeners.Count; i++)
      {
        Event ev = new Event(EventType.eventTypeNumberClick, 2);
        mNumberClickListeners[i].receivedEvent(ev);
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < mNumberClickListeners.Count; i++)
      {
        Event ev = new Event(EventType.eventTypeNumberClick, 3);
        mNumberClickListeners[i].receivedEvent(ev);
      }
    }

    private void button4_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < mNumberClickListeners.Count; i++)
      {
        Event ev = new Event(EventType.eventTypeNumberClick, 4);
        mNumberClickListeners[i].receivedEvent(ev);
      }
    }

    private void button5_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < mNumberClickListeners.Count; i++)
      {
        Event ev = new Event(EventType.eventTypeNumberClick, 5);
        mNumberClickListeners[i].receivedEvent(ev);
      }
    }

    private void button6_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < mNumberClickListeners.Count; i++)
      {
        Event ev = new Event(EventType.eventTypeNumberClick, 6);
        mNumberClickListeners[i].receivedEvent(ev);
      }
    }

    private void button7_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < mNumberClickListeners.Count; i++)
      {
        Event ev = new Event(EventType.eventTypeNumberClick, 7);
        mNumberClickListeners[i].receivedEvent(ev);
      }
    }

    private void button8_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < mNumberClickListeners.Count; i++)
      {
        Event ev = new Event(EventType.eventTypeNumberClick, 8);
        mNumberClickListeners[i].receivedEvent(ev);
      }
    }

    private void button9_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < mNumberClickListeners.Count; i++)
      {
        Event ev = new Event(EventType.eventTypeNumberClick, 9);
        mNumberClickListeners[i].receivedEvent(ev);
      }
    }

    private void button0_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < mNumberClickListeners.Count; i++)
      {
        Event ev = new Event(EventType.eventTypeNumberClick, 0);
        mNumberClickListeners[i].receivedEvent(ev);
      }
    }

    private void buttonClear_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < mClearClickListeners.Count; i++)
      {
        Event ev = new Event(EventType.eventTypeClearClick);
        mClearClickListeners[i].receivedEvent(ev);
      }
    }

    private void buttonAdd_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < mAddClickListeners.Count; i++)
      {
        Event ev = new Event(EventType.eventTypeAddClick);
        mAddClickListeners[i].receivedEvent(ev);
      }
    }

    private void buttonSubtract_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < mSubtractClickListeners.Count; i++)
      {
        Event ev = new Event(EventType.eventTypeSubtractClick);
        mSubtractClickListeners[i].receivedEvent(ev);
      }
    }

    private void buttonEquals_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < mEqualsClickListeners.Count; i++)
      {
        Event ev = new Event(EventType.eventTypeEqualsClick);
        mEqualsClickListeners[i].receivedEvent(ev);
      }
    }

    public void numberUpdated(int number)
    {
      textBox.Text = "" + number;
    }
  }
}
