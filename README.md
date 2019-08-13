# Net Http Library

The NetHttp library is a lightweight library which is build on the principles of Javascripts promises. With this library you can do http request like you do it in javascripts. 

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

1. Open the folder DLL_v_0.2
2. Download the DLL file and add it to your project
3. Add using NetHttp; to the top of your script

### Prerequisites

What things you need to install the software and how to install them

```
Nothing required
```

### Usage

A step by step series of examples that tell you how to get a development env running

1. Create a function which should behave like a promise

```
using NetHttp;
...

public async Task<Promise> Create()
{
    HttpRequest req = new HttpRequest();
    var data = await req.Get("https://jsonplaceholder.typicode.com/todos/1");
    return new Promise(data.body);
}
```

2. Call the function and process the data. ***Be sure that you call promises from "async void" functions***

```
using NetHttp;
...

async void DoPromise(){
    
    Promise prom = await Create();
            
    prom.Then(data =>
    {
      //Write your code here
      return data1;
    });
}
```

3. (Optional) You can use chaining to process data in multiple Then() functions

```
using NetHttp;
...

async void DoPromise(){

    Promise prom = await Create();
            
    prom.Then(data1 =>
    {
   
      return "I'm from the first Then()";
    
    }).Then(data2 => {
    
      Console.Log(data2); //prints "I'm from the first Then()"
      return data2;
      
    });
}   

```


## Deployment

Nothing requrired for Deployment
 

## Authors

* **Onur Özkan** - *Initial work* - [Oni22](https://github.com/Oni22)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc

