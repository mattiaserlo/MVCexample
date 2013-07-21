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

    private int mCurrentNumber = 0;
    private int mStoredNumber = 0;

    private bool mClearOnNextNumber = false;

    private State mCurrentState = State.IDLE;

    private PubSub mPubSub = null;

    public void setPubSub(PubSub pubSub)
    {
      mPubSub = pubSub;
    }

    public void pushNumber(int number)
    {
      if (mClearOnNextNumber == true)
      {
        mCurrentNumber = 0;
        mClearOnNextNumber = false;
      }

      mCurrentNumber *= 10;
      mCurrentNumber += number;

      if (mPubSub != null)
      {
        mPubSub.publish(SubscriptionType.NUMBER_UPDATED, mCurrentNumber);
      }
    }

    public void add()
    {
      mCurrentState = State.ADDING;
      mStoredNumber = mCurrentNumber;
      mClearOnNextNumber = true;
    }

    public void subtract()
    {
      mCurrentState = State.SUBTRACTING;
      mStoredNumber = mCurrentNumber;
      mClearOnNextNumber = true;
    }

    public void clear()
    {
      mCurrentNumber = 0;
      if (mPubSub != null)
      {
        mPubSub.publish(SubscriptionType.NUMBER_UPDATED, mCurrentNumber);
      }
    }

    public void equals()
    {
      if (mCurrentState == State.ADDING)
      {
        mCurrentNumber = mStoredNumber + mCurrentNumber;
      }
      else if (mCurrentState == State.SUBTRACTING)
      {
        mCurrentNumber = mStoredNumber - mCurrentNumber;
      }

      if (mPubSub != null)
      {
        mPubSub.publish(SubscriptionType.NUMBER_UPDATED, mCurrentNumber);
      }

      mCurrentState = State.IDLE;
    }
  }
}
