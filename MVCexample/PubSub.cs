using System;
using System.Collections.Generic;
using System.Text;

namespace MVCexample
{
  public class PubSub
  {
    private List<ISubscription> mSubscribers = new List<ISubscription>();

    public void subscribe(ISubscription subscriber, SubscriptionType type)
    {
      if (type == SubscriptionType.NUMBER_UPDATED)
      {
        mSubscribers.Add(subscriber);
      }
    }

    public void publish(SubscriptionType type, int data)
    {
      if (type == SubscriptionType.NUMBER_UPDATED)
      {
        for (int i = 0; i < mSubscribers.Count; i++)
        {
          mSubscribers[i].numberUpdated(data);
        }
      }
    }
  }
}
