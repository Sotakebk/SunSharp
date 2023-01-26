using SunSharp;
using SunSharp.ObjectWrapper;
using SunSharp.ThinWrapper;

namespace Examples.ExampleCode
{
    internal static class LockCodeTest
    {
        public static void RunExample(ISunVoxLib lib)
        {
            using (var sv = new SunVox(lib))
            {
                DoWork(sv);
            }
        }

        private static void DoWork(SunVox sv)
        {
            SlotLockTest(sv);
            LibraryLockTest(sv);
            MixedLockTest(sv);
        }

        private static void MixedLockTest(SunVox sv)
        {
            Console.WriteLine("Concurrent ISunVoxLib.LockSlot and Slot.RunInLock() test.");

            void Write(string msg)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fffffff}]{msg}");
            }

            sv.Slots[0].Open();
            var library = sv.Library;

            bool firstLockEntered = false;
            bool secondLockEntering = false;
            var t1 = new Task(() =>
            {
                Write("t1 starting...");
                Write("t1 entering...");
                library.LockSlot(0);
                Write("t1 entered");
                firstLockEntered = true;
                Write("t1 entering deeper...");
                library.LockSlot(0);
                Write("t1 entered twice");
                Write("t1 leaving once...");
                library.UnlockSlot(0);
                Write("t1 left once");
                Write("t1 waiting...");
                while (!secondLockEntering) { }
                Write("t1 leaving fully...");
                library.UnlockSlot(0);
                Write("t1 left");
            });

            var t2 = new Task(() =>
            {
                Write("t2 starting...");
                Write("t2 waiting...");
                while (!firstLockEntered) { }
                Write("t2 entering...");
                secondLockEntering = true;
                sv.Slots[0].RunInLock(() =>
                {
                    Write("t2 entered");
                    Write("t2 leaving...");
                });
                Write("t2 left");
            });

            t2.Start();
            t1.Start();
            t1.Wait();
            t2.Wait();

            sv.Slots[0].Close();
        }

        private static void LibraryLockTest(SunVox sv)
        {
            Console.WriteLine("Concurrent ISunVoxLib.LockSlot test with depth.");

            void Write(string msg)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fffffff}]{msg}");
            }

            sv.Slots[0].Open();
            var library = sv.Library;

            bool firstLockEntered = false;
            bool secondLockEntering = false;
            var t1 = new Task(() =>
            {
                Write("t1 starting...");
                Write("t1 entering...");
                library.LockSlot(0);
                Write("t1 entered");
                firstLockEntered = true;
                Write("t1 entering deeper...");
                library.LockSlot(0);
                Write("t1 entered twice");
                Write("t1 leaving once...");
                library.UnlockSlot(0);
                Write("t1 left once");
                Write("t1 waiting...");
                while (!secondLockEntering) { }
                Write("t1 leaving fully...");
                library.UnlockSlot(0);
                Write("t1 left");
            });

            var t2 = new Task(() =>
           {
               Write("t2 starting...");
               Write("t2 waiting...");
               while (!firstLockEntered) { }
               Write("t2 entering...");
               secondLockEntering = true;
               library.LockSlot(0);
               Write("t2 entered");
               Write("t2 leaving...");
               library.UnlockSlot(0);
               Write("t2 left");
           });

            t2.Start();
            t1.Start();
            t1.Wait();
            t2.Wait();

            sv.Slots[0].Close();
        }

        private static void SlotLockTest(SunVox sv)
        {
            Console.WriteLine("Concurrent Slot.RunInLock test.");

            void Write(string msg)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss:fffffff}]{msg}");
            }

            sv.Slots[0].Open();

            bool firstLockEntered = false;
            bool secondLockEntering = false;
            var t1 = new Task(() =>
            {
                Write("t1 starting...");
                Write("t1 entering...");
                sv.Slots[0].RunInLock(() =>
                {
                    Write("t1 entered");
                    firstLockEntered = true;
                    Write("t1 waiting...");
                    while (!secondLockEntering) { }
                    Write("t1 leaving...");
                });
                Write("t1 left");
            });

            var t2 = new Task(() =>
            {
                Write("t2 starting...");
                Write("t2 waiting...");
                while (!firstLockEntered) { }
                Write("t2 entering...");
                secondLockEntering = true;
                sv.Slots[0].RunInLock(() =>
                {
                    Write("t2 entered");
                    Write("t2 leaving...");
                });
                Write("t2 left");
            });

            t2.Start();
            t1.Start();
            t1.Wait();
            t2.Wait();

            sv.Slots[0].Close();
        }
    }
}
