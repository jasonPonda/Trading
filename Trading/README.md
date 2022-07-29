# Trading

## Authentication
As you will build an API, especially sensitive because it's about money, you need to have authentication. A very common mean is to use a token like JWT (JSON web Token), but every major framework come with built-in authentication so hopefully you won't have to worry about it and implement it from scratch.


In the db we will store the following in the TRADE table :

#### TRADE	

|symbol: |	TSLA|
|quantity: | 123|
|open_price: |	103059|
|close_price: |	null|
|open_datetime: | 16h23 25/10/2021 CEST |
|close_datetime: |	null|
|open: | true|

As soon as we close the position (we sell everything) we will update the record in the database like so for instance :

#### TRADE

|symbol:|	TSLA|
|quantity:	|123|
|open_price:	|103059|
|close_price:	|119449|
|open_datetime:	|16h23 25/10/2021 CEST|
|close_datetime:|	11h00 08/11/2021 CEST|
|open:|	false|

We can see that we made a profit because we sold at a higher price $1,194.49

## Endpoints API

##### Method	route	

|GET	/api/login	| Login|
|POST	/api/signup	| Signup|
|POST	/api/wire	| Make a wire (deposit OR withdraw money)|
|GET	/api/profile |	Fetch all the profile data, including the user's balance|
|PATCH	/api/update |	Update user's profile (except balance)|
|GET	/api/trades/index |	Fetch all our trades|
|GET	/api/trades/:id |	Fetch one trade info|
|GET	/api/trades/index/open |	Fetch all our open trades|
|GET	/api/trades/index/closed |	Fetch all our closed trades|
|POST	/api/openTrade/ |	Open a long position (buy), the amount and the stock is specified in the body of the request|
|POST	/api/closeTrade/:id |	Close the position|
|GET	/api/closedPNL |	Return the total closed PNL (all closed trades)|
|GET	/api/openPNL |	Return the total open PNL (all open trades)|
|GET	/api/currentBalance |	Return current balance (all the money that is NOT in an open position)|
