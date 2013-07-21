using System;
using System.Collections.Generic;
using System.Text;

namespace MVCexample
{
  public class Model
  {
    private enum State
    {
      IDLE,
      ADDING,
      SUBTRACTING
    }

    private int currentNumber = 0;
    private int storedNumber = 0;

    private bool clearOnNextNumber = false;

    private State currentState = State.IDLE;

    private PubSub mPubSub = null;

    public void setPubSub(PubSub pubSub)
    {
      mPubSub = pubSub;
    }

    public void pushNumber(int number)
    {
      if (clearOnNextNumber == true)
      {
        currentNumber = 0;
        clearOnNextNumber = false;
      }

      currentNumber *= 10;
      currentNumber += number;

      if (mPubSub != null)
      {
        mPubSub.publish(SubscriptionType.NUMBER_UPDATED, currentNumber);
      }
    }

    public void add()
    {
      currentState = State.ADDING;
      storedNumber = currentNumber;
      clearOnNextNumber = true;
    }

    public void subtract()
    {
      currentState = State.SUBTRACTING;
      storedNumber = currentNumber;
      clearOnNextNumber = true;
    }

    public void clear()
    {
      currentNumber = 0;
      if (mPubSub != null)
      {
        mPubSub.publish(SubscriptionType.NUMBER_UPDATED, currentNumber);
      }
    }

    public void equals()
    {
      if (currentState == State.ADDING)
      {
        currentNumber = storedNumber + currentNumber;
      }
      else if (currentState == State.SUBTRACTING)
      {
        currentNumber = storedNumber - currentNumber;
      }

      if (mPubSub != null)
      {
        mPubSub.publish(SubscriptionType.NUMBER_UPDATED, currentNumber);
      }

      currentState = State.IDLE;
    }
  }
}
