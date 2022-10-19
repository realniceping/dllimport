using System;
using System.Runtime.InteropServices;

namespace dllimport;

public class Program{

    static void Main(string[] args){
        
        DateTime now = DateTime.Now;

        Random rng = new Random();
        IntPtr queue = Connector.queue_init(1, 1);
        for(int i = 0; i < 10000; i++){
            Connector.queue_append(queue, 100000-i, i);
        }

        IntPtr ptr;
        for(int i = 0; i<10001; i++){
            ptr = Connector.queue_pop(queue);
            Console.WriteLine(Marshal.ReadInt32(ptr));
        }

        Console.WriteLine(DateTime.Now - now);
    }

}

