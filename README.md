## Development Notes & Mistakes

- I realised later that I should have that the name of my GetPricedParcel method didn't make sense (it was GetDefaultPricedParcel)
- For step 3 I am assuming that for the cost of being over the weight limit, we should round the weight up to the nearest kg
- I accidentally committed the first change of step 3 straight to master, I noticed this before I pushed, but decided to continue on without rectifying. Usually I would fix this.
- At the end of step 3, I am not sure whether my CostCalculatorUtilities class is getting too bloated. I'm interested to know at what point you would consider having separate files for some of these methods.
- For step 4, I am assuming that the parcel type HeavyParcel is separate from the existing size-based parcel types, such that we should set the type of a parcel as HeavyParcel type regardless of its size if being a HeavyParcel makes the cost of the parcel cheaper.
- I realised at step 4 that I should have put my parcel costs as constants for consistency
