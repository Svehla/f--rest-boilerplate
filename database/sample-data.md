
## Create data

```sql
CREATE TABLE fruits(
   id SERIAL PRIMARY KEY,
   name VARCHAR NOT NULL
);

INSERT INTO fruits(name) 
VALUES('Apple');


INSERT INTO fruits(name) 
VALUES ('Orange');


INSERT INTO fruits(name) 
VALUES('Banana')
RETURNING id;

```


## get data


```sql
select * from fruits
```


