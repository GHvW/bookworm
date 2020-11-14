using System;
using System.Collections.Generic;
using System.Text;

namespace BookWorm {

    public delegate B Reader<A, B>(A item);

    public static class ReaderExtensions {

        public static Reader<A, C> Select<A, B, C>(
            this Reader<A, B> run, 
            Func<B, C> func) => 
                (item) => func(run(item));


        public static Reader<A, C> SelectMany<A, B, C>(
            this Reader<A, B> run, 
            Func<B, Reader<A, C>> func) =>
                (item) => func(run(item))(item);


        public static Reader<A, D> SelectMany<A, B, C, D>(
            this Reader<A, B> run,
            Func<B, Reader<A, C>> func,
            Func<B, C, D> selector) => 
                (item) => run.SelectMany(b => func(b).Select(c => selector(b, c)))(item);
    }


    // just in case
    //public class Reader2<A, B> {

    //    private readonly Func<A, B> run;

    //    public Reader2(Func<A, B> run) {
    //        this.run = run;
    //    }


    //    public Reader2<A, C> Select<C>(Func<B, C> func) =>
    //        new Reader2<A, C>(item => func(this.run(item)));


    //    public Reader2<A, C> SelectMany<C>(Func<B, Reader2<A, C>> func) =>
    //        new Reader2<A, C>(item => func(this.run(item)).run(item));


    //    public Reader2<A, D> SelectMany<C, D>(
    //        Func<B, Reader2<A, C>> func, 
    //        Func<B, C, D> selector) =>
    //            new Reader2<A, D>(item => this.SelectMany(b => func(b).Select(c => selector(b, c))).run(item));
    //}
}
