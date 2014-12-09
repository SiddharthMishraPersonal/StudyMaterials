namespace ObserverPattern
{
  /// <summary>
  /// Interface will contain methods exposed outside world to notify investor about any price change.
  /// </summary>
  public interface IInvestor
  {
    void UpdatePrice(IStock stock);
  }
}
