## Development Notes & Mistakes

- I realised later that I should have that the name of my GetPricedParcel method didn't make sense (it was GetDefaultPricedParcel)
- For step 3 I am assuming that for the cost of being over the weight limit, we should round the weight up to the nearest kg
- I accidentally committed the first change of step 3 straight to master, I noticed this before I pushed, but decided to continue on without rectifying. Usually I would fix this.
- At the end of step 3, I am not sure whether my CostCalculatorUtilities class is getting too bloated. I'm interested to know at what point you would consider having separate files for some of these methods.
- For step 4, I am assuming that the parcel type HeavyParcel is separate from the existing size-based parcel types, such that we should set the type of a parcel as HeavyParcel type regardless of its size if being a HeavyParcel makes the cost of the parcel cheaper.
- I realised at step 4 that I should have put my parcel costs as constants for consistency
- I was unable to start step 5 within the 2 hour time-frame. After reading the instructions my gut instinct is that this is a sort of Dynamic Programming problem, since I can think of scenarios where putting all of your medium parcels into sets of 3 is not necessarily the cheapest option. I would probably try to price parcels as before, then sort them by descending cost. Then I would iterate through the list and collect possible states (e.g. place parcel in current group of 3, or place parcel in current group of 5 if medium) with their savings. Then at the end return the state with the most savings. I could be way off, so I'm interested to discuss this problem further.
- If I had more time on the steps I did complete, I would probably spend a bit more time considering writing other unit tests. I could test my utility functions in isolation as well as covering more of the problem space. I do think my current test suite does give good coverage though.
- There are probably other issues that I haven't considered, and am happy to discuss my design decisions and receive feedback.
- I also didn't include the time for me to set up the initial repo or to write the last part of this README in the 2hr time frame, just for full transparency.
