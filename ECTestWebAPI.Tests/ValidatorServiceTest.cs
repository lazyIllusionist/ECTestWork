using ECTestWebAPI.Models;
using ECTestWebAPI.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECTestWebAPI.Tests
{
    class ValidatorServiceTest
    {
        [Test]
        public void Validate_SendRightForm_TrueResult()
        {
            //Arrenge
            ValidationService service = new ValidationService();

            DateIntervalForm form = new DateIntervalForm
            {
                StartYear = 2000,
                StartMonth = 12,
                StartDay = 1,
                EndYear = 2001,
                EndMonth = 1,
                EndDay = 3
            };

            //Act
            bool result = service.Validate(form);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Validate_SendYearLessThan1_ArgumetExeption()
        {
            //Arrenge
            ValidationService service = new ValidationService();

            DateIntervalForm form = new DateIntervalForm
            {
                StartYear = -1,
                StartMonth = 12,
                StartDay = 1,
                EndYear = 2001,
                EndMonth = 1,
                EndDay = 3
            };

            //Act/Assert
            try
            {
                service.Validate(form);
            }
            catch(ArgumentException e)
            {
                Assert.Pass();
            }
            catch(Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Validate_SendMonthLessThan1_ArgumetExeption()
        {
            //Arrenge
            ValidationService service = new ValidationService();

            DateIntervalForm form = new DateIntervalForm
            {
                StartYear = 2000,
                StartMonth = -12,
                StartDay = 1,
                EndYear = 2001,
                EndMonth = 1,
                EndDay = 3
            };

            //Act/Assert
            try
            {
                service.Validate(form);
            }
            catch (ArgumentException e)
            {
                Assert.Pass();
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Validate_SendDayLessThan1_ArgumetExeption()
        {
            //Arrenge
            ValidationService service = new ValidationService();

            DateIntervalForm form = new DateIntervalForm
            {
                StartYear = 2000,
                StartMonth = 12,
                StartDay = -1,
                EndYear = 2001,
                EndMonth = 1,
                EndDay = 3
            };

            //Act/Assert
            try
            {
                service.Validate(form);
            }
            catch (ArgumentException e)
            {
                Assert.Pass();
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Validate_SendYearBiggerThat9999_ArgumetExeption()
        {
            //Arrenge
            ValidationService service = new ValidationService();

            DateIntervalForm form = new DateIntervalForm
            {
                StartYear = 20000,
                StartMonth = -12,
                StartDay = 1,
                EndYear = 2001,
                EndMonth = 1,
                EndDay = 3
            };

            //Act/Assert
            try
            {
                service.Validate(form);
            }
            catch (ArgumentException e)
            {
                Assert.Pass();
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Validate_SendMonthBiggerThat12_ArgumetExeption()
        {
            //Arrenge
            ValidationService service = new ValidationService();

            DateIntervalForm form = new DateIntervalForm
            {
                StartYear = 2000,
                StartMonth = 13,
                StartDay = 1,
                EndYear = 2001,
                EndMonth = 1,
                EndDay = 3
            };

            //Act/Assert
            try
            {
                service.Validate(form);
            }
            catch (ArgumentException e)
            {
                Assert.Pass();
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Validate_SendDayBiggerThat31_ArgumetExeption()
        {
            //Arrenge
            ValidationService service = new ValidationService();

            DateIntervalForm form = new DateIntervalForm
            {
                StartYear = 2000,
                StartMonth = 12,
                StartDay = 32,
                EndYear = 2001,
                EndMonth = 1,
                EndDay = 3
            };

            //Act/Assert
            try
            {
                service.Validate(form);
            }
            catch (ArgumentException e)
            {
                Assert.Pass();
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Validate_SendEndYearBiggerThatStartYear_ArgumetExeption()
        {
            //Arrenge
            ValidationService service = new ValidationService();

            DateIntervalForm form = new DateIntervalForm
            {
                StartYear = 2002,
                StartMonth = 12,
                StartDay = 1,
                EndYear = 2001,
                EndMonth = 1,
                EndDay = 3
            };

            //Act/Assert
            try
            {
                service.Validate(form);
            }
            catch (ArgumentException e)
            {
                Assert.Pass();
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Validate_SendEndMonthBiggerThatStartMonthYearsAreEquel_ArgumetExeption()
        {
            //Arrenge
            ValidationService service = new ValidationService();

            DateIntervalForm form = new DateIntervalForm
            {
                StartYear = 2002,
                StartMonth = 12,
                StartDay = 1,
                EndYear = 2002,
                EndMonth = 1,
                EndDay = 3
            };

            //Act/Assert
            try
            {
                service.Validate(form);
            }
            catch (ArgumentException e)
            {
                Assert.Pass();
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Validate_SendEndDayBiggerThatStartDayMonthsAndYearsAreEquel_ArgumetExeption()
        {
            //Arrenge
            ValidationService service = new ValidationService();

            DateIntervalForm form = new DateIntervalForm
            {
                StartYear = 2002,
                StartMonth = 12,
                StartDay = 1,
                EndYear = 2002,
                EndMonth = 12,
                EndDay = 3
            };

            //Act/Assert
            try
            {
                service.Validate(form);
            }
            catch (ArgumentException e)
            {
                Assert.Pass();
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }
    }
}
