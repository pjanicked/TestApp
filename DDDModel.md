## Some initial thoughts
- This is my first dive into DDD so I am not really familiar. Would be great to have a exploratory discussion.
- I am not sure if DDD is appropriate here as a Single Entry ledger would be much more straight forward.
- A plain apprach using Entity and DTOs would also work.

## Transaction Class
```
 public int ID { get; set; }
 public EntryType entryType { get; set; }
 //Other props
```

## EntryType ValueObject
```
 public string Type { get; }
 //Other props
 //Inherits IEquatable and IComparable so as to compare just the needed properties
```
