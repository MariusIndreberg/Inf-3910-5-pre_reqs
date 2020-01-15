open System

//Defining functions
module Defining_Functions = 
    //Immutable?
    let foo = 5
    
    //printing stuff, notice the return value!
    //let printStuff = printfn "%A" foo

    let mutable mutableFoo = 10
    mutableFoo <- 10

    //functions with parameters
    let fooFunc fooPar1 fooPar2 = 
        fooPar1 + fooPar2

    //lambdas 
    let fooLambda = fun x -> x + 2
    let foo2lambda = fun x y -> (x * y)

    //Partial Application
    let wat = foo2lambda 2

    let pipeLine x f = f x 


    let funcComposition x y =
        (foo2lambda x >> fooLambda) y


module Records = 
    //Records -> on the surface works like a struct in C.
    type Cat = {
        name : string
        age : int
    }with 
        static member New name age = {
            name = name
            age = age
        }

    type Dog = {
        name : string
        age : int
    }
    with 
        static member New name age = {
            name = name
            age = age
        }

    type Person = {
        firstName : string
        middleName : string option
        lastName : string
        age : int
        child : Person option
    }
    //can add methods to structs either static or not.
    with 
        static member New firstName middleName lastName age  = {
            firstName = firstName
            middleName = middleName
            lastName = lastName
            age = age
            child = None
        }

        member this.SetAge age = 
            //this is syntactic sugar that creates a new record with the same data except for in this instance age.
            {this with age = age}

    //Records have structural equality as opposed to referential equality
    let private person1 = Person.New "Foo" None "Bar" 18

    let private person2 = Person.New "Foo" None "Bar" 18

    let areTheseRecordsEqual = 
        person1 = person2  

    let whatAboutNow = 
        let person2' = person2.SetAge 19
        person1 = person2'      


module Unions = 
    open Records
    
    //Discriminate Unions 
    type PersonOrCat = 
        | Person of Person
        | Cat of Cat

    type Animals = 
        | Cat of Cat 
        | Dog of Dog    

    //single typed Union
    type Email = Email of string

    let createEmail (email : string) = 
        if email.Length <= 30 && email.Length >= 10 then
            email  
            |> Email 
            |> Ok
        else  
            email.Length 
            |> sprintf "Email is not correct lenght, must be more than 10 characters and less than 30, currently is %i"
            |> Error         


    //Two unions which you will use all the time; Option and Result.
    type Option<'a> = 
        | Some of 'a
        | None

    type Result<'a> = 
        | Ok of 'a 
        | Error of string


module PatternMatching = 
    open Unions
    //As records have structural equality this leads to the possiblity of pattern matching!
    let getSound animal = 
        match animal with  
        | Dog d -> printfn "woof"
        | Cat c -> printfn "Meow"    


module VariousCollections = 
    //F# already has a lot of collections ready for use
    //Lists:
    let createList = [0..10]

    //Arrays:
    let arr = [|1;2;3;4;5|]    

    //Sequences:
    let createSeq = Seq.initInfinite(fun idx -> ((idx * 2) - 1))

    //Sets:
    let set1 = [1;2;3;4;5] |> Set.ofList
    let set2 = [4;5;6] |> Set.ofList
    let diff = set1 - set2    
    
    //Map:
    let newMap : Map<string,int> = Map.empty    

    let fillMap = 
        newMap 
        |> Map.add "1" 1
        |> Map.add "2" 2
        |> Map.add "3" 3

    let getValue key (map : Map<string, int>) = 
        map.TryFind key

    let updateMap (map : Map<string, int>) key value = 
        map.Add (key, value)


module CollectionOperations = 
    open Records
    open Unions
    let listOfAnimals = 
        [
            Cat.New "Mittens" 10 |> Cat; 
            Dog.New "Fido" 11 |> Dog;
            Cat.New "Garfield" 17 |> Cat;
            Dog.New "Pluto" 5 |> Dog
        ]

    //map
    let getAnimalAge = 
        listOfAnimals 
        |> List.map ( fun animal -> 
            match animal with  
            | Dog d -> d.age
            | Cat c -> c.age ) 

    //filter
    let getOldAnimals = 
        listOfAnimals 
        |> List.filter ( fun animal -> 
            match animal with  
            | Dog d -> d.age >= 10
            | Cat c -> c.age >= 6)  

    //reduce
    let getTotalAge = 
        getAnimalAge
        |> List.reduce (+) 

    //fold    
    let getTotalAgeFold = 
        getAnimalAge
        |> List.fold (fun acc elem -> acc + elem) 0

    //iter
    let printNames = 
        listOfAnimals
        |> List.iter (fun animal -> 
            match animal with  
            | Dog d -> printfn "%A" d.name
            | Cat c -> printfn "%A" c.name)

//Other stuff??
//Classes and interfaces
//Exceptions
//Active patterns


[<EntryPoint>]
let main argv =
    printfn "Hello from F#!"
    0 // return an integer exit code
