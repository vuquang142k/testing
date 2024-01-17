# Нагрузочное тестирование на GET запросах

Нагрузочное тестирование проводилось со следующими параметрами:
* n = 1000 - общее количество запросов;
* c = 100 - количество одновременно конкурирующих запросов.

## Carter

### Сериализация (Json)

Команда
```
ab -n 1000 -c 100 http://localhost/json
```

Результат
```
This is ApacheBench, Version 2.3 <$Revision: 1901567 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)


Server Software:        Kestrel
Server Hostname:        localhost
Server Port:            80

Document Path:          /json
Document Length:        27 bytes

Concurrency Level:      100
Time taken for tests:   1.477 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      171000 bytes
HTML transferred:       27000 bytes
Requests per second:    677.21 [#/sec] (mean)
Time per request:       147.666 [ms] (mean)
Time per request:       1.477 [ms] (mean, across all concurrent requests)
Transfer rate:          113.09 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.4      0       9
Processing:    40  126  59.0    111     292
Waiting:       24  123  59.8    108     290
Total:         40  126  59.0    111     292

Percentage of the requests served within a certain time (ms)
  50%    111
  66%    142
  75%    170
  80%    187
  90%    211
  95%    236
  98%    249
  99%    281
 100%    292 (longest request)
```

### PlainText

Команда
```
ab -n 1000 -c 100 http://localhost/plaintext
```

Результат
```
This is ApacheBench, Version 2.3 <$Revision: 1901567 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)


Server Software:        
Server Hostname:        localhost
Server Port:            80

Document Path:          /plaintext
Document Length:        13 bytes

Concurrency Level:      100
Time taken for tests:   1.509 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      137259 bytes
HTML transferred:       11817 bytes
Requests per second:    662.48 [#/sec] (mean)
Time per request:       150.947 [ms] (mean)
Time per request:       1.509 [ms] (mean, across all concurrent requests)
Transfer rate:          88.80 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.3      0       3
Processing:     1  118  67.1     92     276
Waiting:        0  115  65.6     91     275
Total:          1  118  67.1     92     276

Percentage of the requests served within a certain time (ms)
  50%     92
  66%    145
  75%    161
  80%    170
  90%    217
  95%    251
  98%    266
  99%    270
 100%    276 (longest request)
```

### Средние запросы

Команда
```
ab -n 1000 -c 100 http://localhost/middle
```

Результат
```
This is ApacheBench, Version 2.3 <$Revision: 1901567 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)


Server Software:        Kestrel
Server Hostname:        localhost
Server Port:            80

Document Path:          /middle
Document Length:        1048572 bytes

Concurrency Level:      100
Time taken for tests:   17.105 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      1048715000 bytes
HTML transferred:       1048572000 bytes
Requests per second:    58.46 [#/sec] (mean)
Time per request:       1710.480 [ms] (mean)
Time per request:       17.105 [ms] (mean, across all concurrent requests)
Transfer rate:          59874.19 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.5      1       9
Processing:   121 1658 397.7   1547    3398
Waiting:       71 1089 275.6   1048    2013
Total:        121 1658 397.7   1547    3399
ERROR: The median and mean for the initial connection time are more than twice the standard
       deviation apart. These results are NOT reliable.

Percentage of the requests served within a certain time (ms)
  50%   1547
  66%   1724
  75%   1856
  80%   1953
  90%   2195
  95%   2517
  98%   2733
  99%   2752
 100%   3399 (longest request)
```

### Тяжелые запросы

Команда
```
ab -n 10000 -c 100 -k http://localhost:5005/heavy
```

Результат
```
This is ApacheBench, Version 2.3 <$Revision: 1901567 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)


Server Software:        Kestrel
Server Hostname:        localhost
Server Port:            80

Document Path:          /heavy
Document Length:        4194300 bytes

Concurrency Level:      100
Time taken for tests:   101.001 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      4194437877 bytes
HTML transferred:       4194294877 bytes
Requests per second:    9.90 [#/sec] (mean)
Time per request:       10100.075 [ms] (mean)
Time per request:       101.001 [ms] (mean, across all concurrent requests)
Transfer rate:          40555.45 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    1   1.0      1      17
Processing:   219 9776 3219.4   8909   23778
Waiting:      145 7263 2916.4   6230   20688
Total:        220 9777 3219.4   8909   23778

Percentage of the requests served within a certain time (ms)
  50%   8909
  66%   9655
  75%  11347
  80%  12132
  90%  15328
  95%  15971
  98%  16850
  99%  20769
 100%  23778 (longest request)
```