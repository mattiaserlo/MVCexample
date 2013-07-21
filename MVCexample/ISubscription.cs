namespace MVCexample
{
  public enum SubscriptionType
  {
    NUMBER_UPDATED
  }

  public interface ISubscription
  {
    void numberUpdated(int number);
  }
}
