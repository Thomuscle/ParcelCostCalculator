## Development Notes & Mistakes

- I realised later that I should have that the name of my GetPricedParcel method didn't make sense (it was GetDefaultPricedParcel)
- For step 3 I am assuming that for the cost of being over the weight limit, we should round the weight up to the nearest kg
- I accidentally committed the first change of step 3 straight to master, I noticed this before I pushed, but decided to continue on without rectifying. Usually I would fix this.
- At the end of step 3, I am not sure whether my CostCalculatorUtilities class is getting too bloated. I'm interested to know at what point you would consider having separate files for some of these methods.
