Java SE:
* Collections(Map - equals, hashCode, collisions; Set - uniqueness, Lists - array and linked, O(?), Arrays - memory locality, cache lines, multidimensional, Queues)
   * HashMap, loadfactor, capacity, java8
* Concurrency(happens-before, thread-safety, immutability, safe publication, primitives - synchronized, wait/notify, volatile, atomic, java.util.concurrent)
   * Synchronizing on final http://stackoverflow.com/questions/6910807/synchronization-of-non-final-field
   * https://shipilev.net/blog/2014/all-fields-are-final/
   * Spinlocks, rwlock, filelock
   * ConcurrentHashMap, how to avoid locking on insert
      * http://javahungry.blogspot.com/2015/02/how-concurrenthashmap-works-in-java-internal-implementation.html
      * https://dzone.com/articles/how-concurrenthashmap-works-internally-in-java
   * http://www.cs.umd.edu/~pugh/java/memoryModel/jsr-133-faq.html
   * http://stackoverflow.com/questions/17108541/happens-before-relationships-with-volatile-fields-and-synchronized-blocks-in-jav
   * http://stackoverflow.com/questions/4934913/are-static-variables-shared-between-threads
   * * Initialization order
   * https://docs.oracle.com/javase/specs/jls/se7/html/jls-8.html
* GC
   * Algorithms & tuning
   * General algorithm of GC(stop the world, etc)
   * Generations
   * Where gc starts?
   * Heap and stack
* IO/NIO
   * Channels/selectors, non-blocking


General:
* OOP design, coupling and cohesion
* Patterns(DI, Singleton, Decorator, Composite, Observer, …)
* SOLID


HTTP:
* HTTP protocol
* HTTP request parts
* RESTful services
* HTTP methods, idempotence, safe
* GET vs POST
* Sessions, cookies
* TCP/HTTP Keep-alive, SO timeouts, HTTP persistent connections
* Apache HttpClient
   * Connection pooling, connection managers
   * Routes, proxies


DB:
* Indexes(range/btree, hash, fulltext), local/global, selectivity, composite, when make sense to use?
* DBMS, relational, ACID
* Partitioning, transactions, transaction isolation levels, query optimization
* NoSQL, CAP theorem, sharding, why to use?
   * Redis, Mongo
* SQL
   * Joins
   * Subqueries(why to use, union all)
   * Aggregate functions, GROUP BY, HAVING
   * 

Spring:
* DI, annotation/xml configuration, context
* MVC/templates
* Component, Service, Repository, Controller
* https://en.wikipedia.org/wiki/Spring_Framework
* AOP
* JDBC
* JMS
* spring-test


JMS:
* Brokers, Sessions, Connection Factories, 
* Pools
* Transactions
* Async
* Concurrent consuming/producing
* Prefetch, broker configurations, performance, disk storage
* ActiveMQ specific, configuration
* Comparison with Kafka
* Spring JMS, async, concurrency, configuration


Java EE:
* Application servers
* JMS, JPA(L2 caches), CDI, JAAS, EJB, JNDI, JMX
* JTA, JTS
* JAX-WS, JAX-RS
* CORBA, IIOP, RMI
* JDBC
   * Connection pools, tuning
   * Alternatives(iBatis, Spring templates and repositories, ORMs)
   * …
* XML, JSON
   * Parsing, JAXB, StAX, SAX
* Transactions
   * https://docs.oracle.com/cd/E19509-01/820-5892/ref_xatrans/index.html
   * http://www.javaworld.com/article/2077714/java-web-development/xa-transactions-using-spring.html
   * 

Additional technologies:
* OLAP(Apache Druid)
* Big Data(Apache Spark, Apache Hadoop)
* Zookeeper, Kafka
* Integration(Spring Integration, Apache Camel)


Development process
* CI
* Code review
* Documentation
* Task tracking
* Static analysis
* VCS(git, svn, mercurial)
   * https://habrahabr.ru/post/161009/


Linux:
* Grep
* Inodes, symlinks, hardlinks
   * http://stackoverflow.com/questions/185899/what-is-the-difference-between-a-symbolic-link-and-a-hard-link
* Filesystems
   * https://en.wikipedia.org/wiki/Block_(data_storage)
   * http://docs.oracle.com/cd/B19306_01/server.102/b14220/logical.htm Segments, extents and datablocks


SBER:
* Hibernate
   * annotations Id, Column, OneToMany, ManyToOne, ..
   * How to implement inheritance in DB(3 ways)
   * Caches, SessionManager, …
* Spring
   * Scopes: singleton(default), prototype
   * What is the difference between spring singleton and manually implemented
   * Why to use spring?(IoC, DI) It’s advantages?
   * How to instantiate spring context?
* Concurrency
   * ThreadLocal implementation
   * Thread states, priorities
   * Wait, notify, notifyall, rules of use(final, synchronization)
   * How to start thread?
   * What is deadlock? How to implement it with wait and notify?
   * What is happens-before? JMM, 
   * Why to use atomics? How are they implemented?
   * How to works wait, notify on Objects? Mutex, what is it?
* Collections
   * Multidimensional arrays, how are they allocated?
   * Hierarchy
   * Rules of implementing equals and hashCode?
* Tomcat threading
   * http://stackoverflow.com/questions/25356703/tomcat-connector-architecture-thread-pools-and-async-servlets
   * http://unix.stackexchange.com/questions/84227/limits-on-the-number-of-file-descriptors
   * http://tutorials.jenkov.com/java-nio/nio-vs-io.html
   *
