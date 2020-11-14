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
}
